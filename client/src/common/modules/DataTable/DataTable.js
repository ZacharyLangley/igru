import React, { useEffect, useState } from 'react';
import {
    Card,
    Toolbar,
    Table,
    SearchField,
    Pagination,
    RadioGroup,
    Dropdown,
    Button
} from 'common/components';
import { makeStyles } from '@material-ui/core/styles';
import AddIcon from '@material-ui/icons/Add';
import {
    limitButtons,
    sortMenu,
    filterMenu
} from './dropdownOptions';
import './DataTable.scss';

const useStyles = makeStyles((theme) => ({
    button: {
        margin: theme.spacing(1),
        backgroundColor: '#4eae53',
        '&:hover': {
            backgroundColor: '#469d4b',
        }
    },
}));

const DataTable = ({
    columns,
    onRowClick,
    getData,
    dataKey,
    countKey,
    addButtonLabel,
    onAddButtonClick,
    tableHeight
}) => {
    const [data, setData] = useState({})
    const [values, setValues] = useState({
        pagination: {
            pageNumber: 1,
            offset: 0
        },
        limit: '30',
        search: '',
        startDate: undefined // Backend Implementation required
    })

    const classes = useStyles();

    useEffect(() => {
        const fetchData = async () => {
            const data = await getData(values.limit, values.offset, values.startDate);
            setData(data)
        }
        
        fetchData();
    }, [values.limit, values.offset])

    const handleChange = (prop) => (event) => {
        setValues({ ...values, [prop]: event.target.value });
    };

    const handlePageChange = (event, page) => {
        const calcOffset = (page - 1) * parseInt(values.limit);
        setValues({ ...values, pagination: { pageNumber: page, offset: calcOffset } });
    }

    const pageCount = data[`${countKey}`] / values.limit

    return (
        <Card
            body={
                <div className={'data-table-container'}>
                    <Toolbar 
                        left={<SearchField onChange={handleChange('search')} onSubmit={() => { console.log(values.search) }}/>} 
                        right={
                            <div className={'utility-container'}>
                                <Dropdown menuItems={sortMenu}>
                                    {'Sort'}
                                </Dropdown>
                                <Dropdown menuItems={filterMenu}>
                                    {'Filter'}
                                </Dropdown>
                                <Button
                                    variant="contained"
                                    color={'secondary'}
                                    className={classes.button}
                                    size={'medium'}
                                    onClick={onAddButtonClick}
                                    startIcon={<AddIcon />}>
                                    {addButtonLabel}
                                </Button>
                            </div>
                        }
                    />
                    <Table
                        data={data[`${dataKey}`]}
                        columns={columns}
                        height={tableHeight}
                        rowCount={data[`${countKey}`]}
                        onRowClick={() => { console.log('click')} }
                    />
                    <Toolbar 
                        left={
                            <RadioGroup
                                label={'Limit'}
                                value={values.limit}
                                radioButtons={limitButtons}
                                defaultValue={limitButtons[0].value}
                                onChange={handleChange('limit')}
                                ariaLabel={'limit'}
                                name={'limit'}
                            />}
                        right={
                            <Pagination
                                defaultPage={1}
                                page={values.pagination.pageNumber}
                                onChange={handlePageChange}
                                count={(pageCount < 1) ? 1 : pageCount}
                            />}
                    />
                </div>
            }
        />
    )
}

export default DataTable