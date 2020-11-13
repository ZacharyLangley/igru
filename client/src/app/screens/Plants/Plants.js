import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import { DataTable } from 'common/modules';
import { getPlantList } from 'domain/actions/plantActions';

const columns = [
    {
        label: 'Name',
        dataKey: 'name',
        width: 200
    },
    {
        label: 'Comments',
        dataKey: 'comment',
        width: 300
    },
    {
        label: 'Gender',
        dataKey: 'gender',
        width: 200
    },
    {
        label: 'Origin',
        dataKey: 'origin',
        width: 200
    },
    {
        label: 'Last Updated',
        dataKey: 'lastUpdated',
        width: 300
    },
]

const Plants = () => {
    return (
        <div>
            <DataTable 
                columns={columns}
                dataKey={'plants'}
                countKey={'plantCount'}
                getData={getPlantList}
                addButtonLabel={'Add Plant'}
            />
        </div>
    )
}

const mapStateToProps = (state) => ({})

const mapDispatchToProps = {
    push,
    getPlantList
}

export default connect(mapStateToProps, mapDispatchToProps)(Plants)