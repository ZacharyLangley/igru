import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import { DataTable } from 'common/modules';
import { getGardenList } from 'domain/actions/gardenActions';

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
    return (
        <div>
            <DataTable 
                columns={columns}
                dataKey={'gardens'}
                countKey={'gardenCount'}
                getData={getGardenList}
                addButtonLabel={'Add Garden'}
            />
        </div>
    )
}

const mapStateToProps = (state) => ({})

const mapDispatchToProps = {
    push,
    getGardenList
}

export default connect(mapStateToProps, mapDispatchToProps)(Gardens)