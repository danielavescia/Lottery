import  "./Navbar.css";

const menuOptions = ['TICKETS'];
const links = ['/Tickets'];

function Navbar()
{
    return (
        <div className='navbar-container'>
            <header>
            <ul className='navbar-ul' >

                { menuOptions.map(( options) => (
                
                    <li className = 'navbar-links'>{ options }</li>
                ) ) }
           </ul>
           </header>
        </div>
           
    );
}
export default Navbar;
