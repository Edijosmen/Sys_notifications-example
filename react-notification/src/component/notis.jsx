import React, { useEffect, useState } from 'react';
import io from 'socket.io-client';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { Field, Form, Formik } from 'formik';
import axios from 'axios';
const ActualizacionRegistroComponent = ({Getnotification}) => {
    const [options,setOptions] = useState([]);
    const notification ={
        message:'Tienes un nuevo ticket asignado',
        state:false,
        userId:''

    }
    const [mensaje, setMensaje] = useState("");

    useEffect(() => {
      const connection = new HubConnectionBuilder()
        .withUrl("http://localhost:5028/chatHub")
        .withAutomaticReconnect()
        .build();
        connection.on('ReceiveMessage', (message) => {
          console.log(`Received message: ${message}`);
          Getnotification(message);
        });
      
  connection.start()
      .then(() => {
          console.log('Connection started!');
          let authToken = localStorage.getItem("Token");
          connection.invoke('AssociateUser', authToken);
      })
      .catch((error) => {
          console.error(`Error starting connection: ${error}`);
      });

        axios.get("http://localhost:5028/api/Accounts/Get_User")
            .then((response) => {
                setOptions(response.data);
            });
      
    }, []);
    return (
        <div>
            {/* Contenido del componente ... */}
            contedigo : {mensaje}
            <Formik 
                initialValues={notification}
                onSubmit={(values)=>{
                    console.log(values);
                    axios.post("http://localhost:5028/api/Notification",values)
                        .then(response=>{
                            console.log(response);
                        });
                }}
            >
            {()=>(
                <Form>
                    <Field as="select" name="userId">
                    {options.map(options =>(
                        <option key={options.id} value={options.id}>{options.userName}</option>
                    ))}
                    </Field>
                    <button type='submit'>enviar </button>
                </Form>
            )}

            </Formik>
        </div>
    );
};

export default ActualizacionRegistroComponent;
