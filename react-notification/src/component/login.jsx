import axios from 'axios';
import { Field,Form, Formik,ErrorMessage } from 'formik'
import React from 'react'
import { useNavigate } from 'react-router-dom';

export default function Login() {
    const navigate = useNavigate();
    const login ={
        email: '',
        password: '', 
    }
  return (
    <div className='login'>
      <Formik
        initialValues={login}
        validate={(values) => {
            let errors = {};
            if (!values.email) {
                errors.email = "el usuario es requerido"
            }
            if (!values.password) {
                errors.password = "el Password es requerido"
            }
            return errors
        }}
        onSubmit={(values) => {
            axios.post("http://localhost:5028/api/Accounts/login",values).then((response) =>{       
                          if(response.status ===200){
                            console.log(response);
                            localStorage.setItem("Token",response.data.token);
                            navigate("/");
                          }
                            
                        },(errors) =>{
                            if(errors.response.status ===400){
                                console.log(errors);
                            }
                        })
        }}
      >
        {({errors})=>(
                       <Form className='col-xs-12 col-md-4 col-lg-4'>
                            <div className='mb-3'>
                                <label className='form-label align-items-end' htmlFor='usuario'>Usuario</label>
                                <Field className='form-control' type='text' name='email' ></Field>
                                <ErrorMessage name='email' component={()=> (
                                    <div className='error'>{errors.email}</div>
                                )}/>
                            </div>
                            <div className='mb-3'>
                                <label className='form-laber' htmlFor='password'>Password</label>
                                <Field className='form-control' type='password' name='password'></Field>
                                <ErrorMessage name='password' component={()=> (
                                    <div className='error'>{errors.password}</div>
                                )}/>
                            </div>
                            <button type='submit'>login </button>
                       </Form>
                    )}
      </Formik>
    </div>
  )
}
