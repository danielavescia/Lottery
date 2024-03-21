import NumberSelector from "../NumberSelector/NumberSelector";
import "./form.css";
import { useState } from 'react';
import axios from 'axios';
function Form() {

    const array = Array.from({ length: 5 }, () => null); //creating array that accepts 5 numbers for the lottery ticket
    const [cpf, setCpf] = useState('');
    const [name, setName] = useState('');
    const [selectedNumbers, setSelectedNumber] = useState(array);   //creating state for selectednumber with array
    

    const handleCpfChange = (e) => { //tracks  events in cpf variable
        setCpf(e.target.value);
    };

    const handleNameChange = (e) => { // tracks events in name variable
        setName(e.target.value);
    };
     
    const handleSubmit = async (e) => {   //
        //e.preventDefault(); //prevent page to refresh
        let ticketLottery = {  //creating body for POST request
            "Cpf": cpf,
            "Name": name,
            "SelectedNumbers": selectedNumbers
        };

        console.log(ticketLottery);

        try {

            const response = await axios.post('https://localhost:7030/Ticket', ticketLottery); //http request
            console.log('Response:', response.data);

        } catch (error) {

            console.error('Error response:', error);
        }
    };

    const handleSubmitRandomTicket = async (e) => {
       // e.preventDefault(); //prevent page to refresh
        let randomTicketLottery = {  //creating body for POST request
            "Cpf": cpf,
            "Name": name,
        };

        try {

            const response = await axios.post('https://localhost:7030/randomTicket', randomTicketLottery); //http POST request
            console.log('Response:', response.data);

        } catch (error) {

            console.error('Error response:', error);
        }
        
    }
    
    const handleGetResults = async (e) => {

        try {

            const response = await axios.get('https://localhost:7030/Result'); //http GET request
            console.log('Response:', response.data);

        } catch (error) {

            console.error('Error response:', error);
        }
    };
    

    return (
        <div >
            <section>
                <p className= "form-paragraph"> Digite os dados abaixo para completar a sua aposta:</p>
                <div className="form-container">
                    <form>
                        <label className="label-form"> CPF:</label>
                            <input
                                className="input-form"
                                type="text"
                                size="11"
                                value={cpf}
                                placeholder="XXX.XXX.XXX-XX"
                                required
                                onChange={handleCpfChange}
                            />

                        <label className="label-form"> NOME:  </label>
                            <input
                                className="input-form"
                                type="text"
                                size="100"
                                required
                                value={name}
                                placeholder="Digite seu nome"
                                onChange={handleNameChange}
                            />
                     </form>
                </div>
            </section>
            <NumberSelector selectedNumber={selectedNumbers} />
            <p>{console.log(cpf)}</p>
            <p>{console.log(name)}</p>
            <p>{console.log(selectedNumbers) }</p>
            <div className="button-container ">
                <button className="button-form" onClick={(e) => handleSubmit(e)}>Enviar</button>
                <button className="button-form" onClick={(e) => handleSubmitRandomTicket(e)}> Aposta Surpresinha</button>
                <button className="button-form" onClick={(e) => handleGetResults(e)}> Encerrar Apostas</button>
            </div>
        </div>

    );
}
export default Form;


    