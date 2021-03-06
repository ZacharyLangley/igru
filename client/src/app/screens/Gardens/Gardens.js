import React, {useState} from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import { DashboardTemplate } from 'common/components';
import { DataTable } from 'common/modules';
import { getGardenList } from 'domain/actions/gardenActions';
import CreateGardenDialog from './Dialogs/CreateGardenDialog/CreateGardenDialog';
const columns = [
    {
        label: 'Name',
        dataKey: 'name',
        width: 150
    },
    {
        label: 'Location',
        dataKey: 'location',
        width: 100
    },
    {
        label: 'Grow Style',
        dataKey: 'growStyle',
        width: 100
    },
    {
        label: 'Grow Type',
        dataKey: 'growType',
        width: 100
    },
    {
        label: 'Grow Size',
        dataKey: 'growSize',
        width: 200
    },
    {
        label: 'Last Updated',
        dataKey: 'lastUpdated',
        width: 300
    },
]

const Gardens = () => {
    const [open, setOpen] = useState(true);
  
    const handleClickOpen = () => {
      setOpen(true);
    };
  
    const handleClose = (value) => {
      setOpen(false);
    };

    return (
        <div>
            <DashboardTemplate
                top={<div style={{ height: '250px' }}>{'TBD Top Modules'}</div>}
                bottom={
                    <DataTable 
                        columns={columns}
                        dataKey={'gardens'}
                        countKey={'gardenCount'}
                        getData={getGardenList}
                        addButtonLabel={'Add Garden'}
                    />
                }
            />
            <CreateGardenDialog onClose={handleClose} open={open}/>
        </div>
    )
}

const mapStateToProps = (state) => ({})

const mapDispatchToProps = {
    push,
    getGardenList
}

export default connect(mapStateToProps, mapDispatchToProps)(Gardens)