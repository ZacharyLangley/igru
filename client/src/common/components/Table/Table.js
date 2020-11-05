import React from 'react';
import {
  Column,
  Table as VirtTable,
  AutoSizer
} from 'react-virtualized';
import { string, object, func, array } from 'prop-types';

import 'react-virtualized/styles.css';
import './Table.scss';

const Table = ({
  data,
  onRowClick,
  columns,
  height,
  rowCount,
  ...props
}) => {
  return (
    <div className={'data-table-container'}>
        {
            data &&
            <AutoSizer disableHeight>
                {({width}) => (
                    <VirtTable
                        width={width}
                        height={height ? height : 250}
                        headerHeight={30}
                        headerClassName={'.header-column'}
                        rowHeight={40}
                        rowCount={rowCount}
                        rowGetter={({ index }) => data[index]}
                        noRowsRenderer={noRowsRenderer}
                        rowClassName={rowClassName}
                        onRowClick={onRowClick ? onRowClick : defaultRowClick}
                        {...props}>
                            {mapColumns(columns)}
                    </VirtTable>
                )}
            </AutoSizer>
        }
    </div>
  );
}

export const defaultRowClick = ({ event, index, rowData}) => {}

export const percentRenderer = ({cellData}) => (`${cellData * 100} %`)

export const noRowsRenderer = () => (
    <div className={'no-rows'}>{'No Data'}</div>
)

export const rowClassName = ({index}) => {
    if (index < 0) {
        return 'header-row';
      } else {
        return index % 2 === 0 ? 'even-row' : 'odd-row';
      }
}

export const mapColumns = (columns) => {
    return columns.map((column, index) => (
            <Column 
                key={index}
                className={'default-column'} 
                {...column}/> 
    ))
}

Table.propTypes = {
  columns: array,
  query: string,
  queryName: string,
  subscription: string,
  subscriptionName: string,
  onRowClick: func,
  searchResults: object,
}

export default Table;