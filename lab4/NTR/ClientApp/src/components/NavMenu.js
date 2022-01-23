import React, { Component, useState, useEffect } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Cookies from 'js-cookie';




export  default function NavMenu() {
    const [name, setName] = useState("");
    useEffect(() => {
      var cookie = Cookies.get('user');
      setName(cookie);
   }, []);

    function logoutUser(){
      console.log(document.cookie);
      fetch(`api/home/logout`, {method:'POST'});
      setName("");
    }

   
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/"> {name}</NavbarBrand>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/activities">Activities</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/partakes">Project Partakings</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="text-dark" onClick={logoutUser}>Logout</NavLink>
                </NavItem>
              </ul>
          </Container>
        </Navbar>
      </header>
    );
  
}
