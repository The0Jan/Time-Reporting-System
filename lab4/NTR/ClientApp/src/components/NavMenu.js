import React, {useState, useEffect } from 'react';
import {Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Cookies from 'js-cookie';




export  default function NavMenu() {
    const [name, setName] = useState("");
    useEffect(() => {
      setName("")
    }, []);

    function reCookie(){
      var cookie = Cookies.get('user');
      setName(cookie);
    }

    function logoutUser(){
      console.log(document.cookie);
      fetch(`api/home/logout`, {method:'POST'});
      setName("");
    }

    const loggedOut = (
      <>
        <NavItem>
          <NavLink tag={Link} className="icon-bar" onClick={reCookie} to="/activities">Enter</NavLink>
        </NavItem>
      </>
    );

    const loggedIn = (
      <>
        <NavItem>
          <NavLink tag={Link} className="text-dark" onClick={reCookie} to="/activities">Activities</NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" onClick={reCookie} to="/partakes">Project Partakings</NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" onClick={logoutUser} to="/">Leave</NavLink>
        </NavItem>
      </>
    );

    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand > {name}</NavbarBrand>
              <ul className="navbar-nav flex-grow">
                {name === "" ? loggedOut : loggedIn}
              </ul>
          </Container>
        </Navbar>
      </header>
    );
  
}
