import "./App.css";
import Form from "./Components/Form/Form";
import Navbar from "./Components/NavBar/Navbar";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <div className="h1-lottery">
                    <h1>Lotery</h1>
                    <Navbar></Navbar>
                    <Form></Form>
                </div>
            </header>
        </div>
    );
}

export default App;
