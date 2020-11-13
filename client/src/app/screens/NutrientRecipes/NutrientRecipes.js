import React from 'react';
import { connect } from 'react-redux'
import { push } from 'connected-react-router'
import { DashboardTemplate } from 'common/components';

import { DataTable } from 'common/modules';
import { getNutrientRecipeList } from 'domain/actions/nutrientRecipeActions';

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
        label: 'Mix Time',
        dataKey: 'mixTime',
        width: 200
    },
    {
        label: 'pH',
        dataKey: 'ph',
        width: 200
    },
    {
        label: 'Last Updated',
        dataKey: 'lastUpdated',
        width: 300
    },
];

const NutrientRecipes = () => {
    return (
        <div>
            <DashboardTemplate
                bottom={
                    <DataTable 
                        columns={columns}
                        dataKey={'nutrientRecipes'}
                        countKey={'nutrientRecipeCount'}
                        getData={getNutrientRecipeList}
                        addButtonLabel={'Add Nutrient Recipe'}
                        tableHeight={500}
                    />
                }
            />
        </div>
    )
}

const mapStateToProps = (state) => ({})

const mapDispatchToProps = {
    push,
    getNutrientRecipeList
}

export default connect(mapStateToProps, mapDispatchToProps)(NutrientRecipes)