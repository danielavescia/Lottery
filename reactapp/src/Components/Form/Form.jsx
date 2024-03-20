import NumberSelector from "../NumberSelector/NumberSelector";
import "./form.css";
import { useState } from 'react';
import axios from 'axios';

function Form() {

    const array = Array.from({ length: 5 }, () => null); //creating array that accepts 5 numbers for the lottery ticket
    const [cpf, setCpf] = useState('');
    const [name, setName] = useState('');
    const [selectedNumber, setSelectedNumber] = useState(array);   //creating state for selectednumber with array
    const [errors, setErrors] = useState({});
    const [submitting, setSubmitting] = useState(false);
 

    const handleCpfChange = (e) => { //tracks the cpf 
        setCpf(e.target.value);
    };

    const handleNameChange = (e) => { //tracks the name 
        setName(e.target.value);
    };
     
    const handleSubmit = async (e) => {   //
        e.preventDefault(); //prevent page to refresh
        let ticketLottery = { cpf, name, selectedNumber };
        console.log(ticketLottery);

        try {
            const response = await axios.post('https://localhost:7030/Ticket', ticketLottery);
            console.log('Response:', response.data);
        } catch (error) {
            console.error('Error submitting data:', error);
        }
    };
   
  
        //setErrors(validateCpf(cpf));
        //setSubmitting(true);

    const validateCpf = (cpfValue) => {

        const regexCpf = /^\d{11}$/; // only numbers with 11 digits

        let errors = {};
        if (cpfValue.length < 11) {
            errors.cpf = "Check your cpf number! It should have eleven numbers";
        }
        if (!cpfValue.test(regexCpf)) {
            errors.cpf = "Are accepted just numbers";
            return errors;
        }

    };

    return (
        <div >
            <section>
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
                
                        <span className="error">{errors["name"]}</span>
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
                        <span className="error">{errors["name"]}</span>
             </form>
             </div>
            </section>
            <NumberSelector selectedNumber={selectedNumber} />
            <p>{console.log(cpf)}</p>
            <p>{console.log(name)}</p>
            <p>{console.log(selectedNumber) }</p>
            <div className="button-container ">
                <button className="button-form" onClick={(e) => handleSubmit(e)}>Enviar</button>
                <button className="button-form"> Aposta Surpresinha</button>
            </div>
        </div>

    );
}
export default Form;


    