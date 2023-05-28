import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ActualizacionRegistroComponent from './component/notis'
import { BrowserRouter, Route, Router, Routes  } from 'react-router-dom'
import Home from './pages/Home'
import Login from './component/login'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <BrowserRouter>
    
       <Routes>
       <Route path='/' Component={Home} />
       <Route path='/login' Component={Login}/>
       </Routes>
  
      </BrowserRouter>
     
    </>
  )
}

export default App
