import React, { useEffect, useState, useRef } from 'react';
import './Dropdown.scss';

import MaterialButton from '@material-ui/core/Button';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import Grow from '@material-ui/core/Grow';
import Paper from '@material-ui/core/Paper';
import Popper from '@material-ui/core/Popper';
import MenuItem from '@material-ui/core/MenuItem';
import MenuList from '@material-ui/core/MenuList';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((theme) => ({
    root: {
      display: 'flex',
    },
    paper: {
      marginRight: theme.spacing(2),
    },
    button: {
      margin: theme.spacing(1),
    },
  }));

const Dropdown = ({
    children,
    menuItems,
    transparent
}) => {
    const classes = useStyles();
    const [open, setOpen] = useState(false);
    const anchorRef = useRef(null);
    // return focus to the button when we transitioned from !open -> open
    const prevOpen = useRef(open);
  
    useEffect(() => {
        if (prevOpen.current === true && open === false) {
          anchorRef.current.focus();
        }
    
        prevOpen.current = open;
      }, [open]);

    const handleToggle = () => {
      setOpen((prevOpen) => !prevOpen);
    };
  
    const handleClose = (event, onSelect = () => {}) => {
      if (anchorRef.current && anchorRef.current.contains(event.target)) {
        return;
      }
      onSelect();
      setOpen(false);
    };
  
    const handleListKeyDown = (event) => {
      if (event.key === 'Tab') {
        event.preventDefault();
        setOpen(false);
      }
    }

    const mapMenuItems = (menuItems) => {
        return menuItems.map((item, index) => {
            return <MenuItem key={index} onClick={(event) => handleClose(event, item.onSelect)}>{item.title}</MenuItem>
        })
    }

    return (
        <div className={classes.root}>
            <MaterialButton
              ref={anchorRef}
              aria-controls={open ? 'menu-list-grow' : undefined}
              aria-haspopup="true"
              size={'medium'}
              className={classes.button}
              color={transparent ? undefined : 'primary'}
              variant={transparent ? undefined : "contained"}
              onClick={handleToggle}
            >
              {children}
            </MaterialButton> 
            <Popper open={open} anchorEl={anchorRef.current} role={undefined} placement={'bottom-end'} transition disablePortal>
            {({ TransitionProps, placement }) => (
                <Grow
                {...TransitionProps}
                style={{ transformOrigin: placement === 'bottom' ? 'center top' : 'center bottom' }}
                >
                <Paper>
                    <ClickAwayListener onClickAway={handleClose}>
                    <MenuList autoFocusItem={open} id="menu-list-grow" onKeyDown={handleListKeyDown}>
                        {mapMenuItems(menuItems)}
                    </MenuList>
                    </ClickAwayListener>
                </Paper>
                </Grow>
            )}
            </Popper>
        </div>
    )
}

export default Dropdown;