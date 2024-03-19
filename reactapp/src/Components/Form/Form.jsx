import NumberSelector from "../NumberSelector/NumberSelector";
import "./form.css";
import { useState } from 'react';

function Form() {

    const [cpf, setCpf] = useState('');
    const [name, setName] = useState('');
    const [errors, setErrors] = useState({});
    const [submitting, setSubmitting] = useState(false);

    const handleCpfChange = (e) => {
        setCpf({ [e.target.cpf]: e.target.value });
    };
    const handleNameChange = (e) => {
        setCpf({ [e.target.cpf]: e.target.value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        setErrors(validateCpf(cpf));
        setSubmitting(true);
    };


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

    }

    return (
        <div >
            <section>
            <div className="form-container">
            <form>
                <label className="label-form">
                    CPF:
                    <input
                                className="input-form"
                                type="text"
                                size="30"
                                //value={cpf}
                                placeholder="XXX.XXX.XXX-XX"
                                onChange={handleCpfChange}
                    />
                        </label>

                        <span className="error">{errors["name"]}</span>
                        <label className="label-form">
                            Nome:  
                            <input
                                className="input-form"
                                type="text"
                                size="100"
                                //value={nome}
                                placeholder="Digite seu nome"
                                onChange={handleNameChange}
                            />
                        </label>

                        <span className="error">{errors["name"]}</span>
             </form>
             </div>
            </section>
            <NumberSelector />
            <div className="button-container">
            <button className="button-form">Enviar</button>
                <button className="button-form">Aposta Surpresinha</button>
            </div>
        </div>

    );
}
export default Form;


    