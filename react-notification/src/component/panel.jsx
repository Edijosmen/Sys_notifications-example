import React, { useEffect, useState } from 'react'
import {AiOutlineHome} from 'react-icons/ai'
import {TbTicket} from 'react-icons/tb'
import {IoMdNotificationsOutline} from 'react-icons/io'
import { Link } from 'react-router-dom'
import './css/panel.css'
import axios from 'axios'
export default function Panel({notifications}) {
  const [notis,setNotis] = useState();
  useEffect(()=>{
    const token = localStorage.getItem("Token");
    axios.get("http://localhost:5028/api/Notification/notopen",{
      headers:{
        'Authorization':`Bearer ${token}`,
      }
    }).then((response)=>{
      console.log(response);
      setNotis(response.data);
    }).catch((error)=>{
      console.error(error);
    });
  },[])

  return (
    <div className='panel'>
      <div className='panel-control'>
        <AiOutlineHome className='icons'></AiOutlineHome>
        <label className='txt'>Panel de Control</label>
      </div>
      <hr/>
      <section className='panel-content'>
        <div  className='item'>
          <AiOutlineHome className='icons'></AiOutlineHome>
          <label className='txt'>Usuario</label>
        </div>
        <Link className='txt link' to="#">Listar usuario</Link>
        <Link className='txt link' to="#">Crear usuario</Link>
        <div className='item'>
          <TbTicket className='icons'></TbTicket>
          <label className='txt' >Ticket</label>
        </div>
        <Link className='txt link' to="#">Ver</Link>
        <div className='item'>
          <IoMdNotificationsOutline className='icons'></IoMdNotificationsOutline>
          <label className='txt' >Notificación {notifications===0 ? notis:notifications}</label>
        </div>
      </section>
    </div>
  )
}
