
const menuOptions = ['TICKETS', 'RESULTS'];
const links = ['/Tickets', '/Results'];

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
