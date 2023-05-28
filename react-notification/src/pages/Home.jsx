import React, { useEffect, useState } from 'react'
import Panel from '../component/panel'
import axios, { Axios } from 'axios'
import ActualizacionRegistroComponent from '../component/notis'

export default function Home() {
  const [notifications,setNotifications] =useState(0);
  useEffect(()=>{
    const token = localStorage.getItem("Token");
    axios.get("http://localhost:5028/api/Notification",{
      headers: {
        'Authorization': `Bearer ${token}`,
      }
    }).then(response=>{
      console.log(response);
    })

  },[])
  function Getnotification(n_notis){
    setNotifications(n_notis);
  }
  console.log("desde padre home:",notifications);  
  return (
    <div>
        <Panel notifications={notifications}></Panel>
        <ActualizacionRegistroComponent Getnotification={Getnotification}></ActualizacionRegistroComponent>
    </div>
  )
}
