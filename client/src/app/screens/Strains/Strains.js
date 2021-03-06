import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'

import { DashboardTemplate } from 'common/components';
import { DataTable } from 'common/modules';
import { getStrainList } from 'domain/actions/strainActions';

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
        label: 'Tags',
        dataKey: 'tags',
        width: 300
    },
    {
        label: 'Last Updated',
        dataKey: 'lastUpdated',
        width: 300
    },
];

const Strains = () => {
    return (
        <div>
            <DashboardTemplate
                top={<div style={{ height: '250px' }}>{'TBD Top Modules'}</div>}
                bottom={
                    <DataTable 
                        columns={columns}
                        dataKey={'strains'}
                        countKey={'strainCount'}
                        getData={getStrainList}
                        addButtonLabel={'Add Strain'}
                    />
                }
            />
        </div>
    )
}

const mapStateToProps = (state) => ({})

const mapDispatchToProps = {
    push,
    getStrainList
}

export default connect(mapStateToProps, mapDispatchToProps)(Strains)