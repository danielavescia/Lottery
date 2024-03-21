import React, { useState } from "react";
import "./number-selector.css";


function createArrayNumbers() {
    var numbers = [];
    for (var i = 1; i < 51; i++) {
        numbers.push(i);
    }
    return numbers;
}

function NumberSelector(props) {

    const selectedNumbers = props.selectedNumber;

    const [errors, setErros] = useState() //creating state for errors

    var numbers = createArrayNumbers(); //creating array of numbers in the range 0-50

    const handleNumberClick = (number) => {
       
        if (selectedNumbers.includes(null)) {   //if array its not full
            let index = selectedNumbers.indexOf(null); //receive the first index that has null
            selectedNumbers[index] = parseInt(number); //receive the clicked number into the index and parses it to int

        } else {
            selectedNumbers.shift(); //eliminates the first one in the array
            selectedNumbers.push(parseInt(number)); //push the number to the end and parses it to int
        }   
        
        console.log(selectedNumbers); 
    };
   
    return (
        <div className="gamble-container">
            <div className="number-selector-container">
                {numbers.map((number) => (
                    <div
                        key={number}
                        className="div-number"
                        onClick={() => handleNumberClick(number)}
                        value={number}
                    >
                        {number}
                    </div>
                ))}
            </div>
        </div>
    );
}

export default NumberSelector;
