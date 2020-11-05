import React from 'react';
import MaterialPagination from '@material-ui/lab/Pagination';

const Pagiantion = ({
    count,
    color,
    size,
    page,
    defaultPage,
    onChange
}) => (
  <MaterialPagination 
      count={count ? count : 10} 
      color={color ? color : 'primary'}
      size={size ? size : 'small'}
      defaultPage={defaultPage}
      page={page}
      onChange={onChange}
      showFirstButton 
      showLastButton
  />
);

export default Pagiantion;