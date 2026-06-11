import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import {DwarfTable} from './DwarfMenu/DwarfTable'
import {DwarfDetail} from './DwarfMenu/DwarfDetail'

function App() {
  return (
    <>
        <DwarfTable/>
        <DwarfDetail />
    </>
  )
}

export default App
