import React, { useState } from "react";
import "./number-selector.css";

function createArrayNumbers() {
    var numbers = [];
    for (var i = 1; i < 51; i++) {
        numbers.push(i);
    }
    return numbers;
}

function NumberSelector() {

    const array = Array.from({ length: 5 }, () => null); //creating array that accepts 5 numbers for the lottery ticket

    const [selectedNumber, setSelectedNumber] = useState(array);   //creating state for selectednumber with array

    const [errors, setErros] = useState() //creating state for errors

    var numbers = createArrayNumbers(); //creating array of numbers in the range 0-50

    const handleNumberClick = (number) => {
        let arrayNumber = [...selectedNumber]

        if (selectedNumber.includes(null)) {   //if array its not full
            arrayNumber = [...selectedNumber]; //receives array selectedNumber
            let index = arrayNumber.indexOf(null); //receives the first index that has null
            arrayNumber[index] = number; //receives the clicked number into the index
            setSelectedNumber(arrayNumber);
            

        } else {
            arrayNumber = [...selectedNumber];
            arrayNumber.shift(); //eliminates the first one in the array
            arrayNumber.push(number); //push the number to the end
            setSelectedNumber(arrayNumber);
        }
        console.log(selectedNumber); 
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
