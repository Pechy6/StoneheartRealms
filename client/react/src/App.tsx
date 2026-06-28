import {BrowserRouter, Routes, Route} from 'react-router-dom'
// Nav
import {Navigation} from './Components/Navigation/Navigation'
import {HomePage} from './Components/Pages/Home/HomePage'
import {FortressPage} from './Components/Pages/Fortress/FortressPage'
import {SurroundingsPage} from './Components/Pages/Surroundings/SurroundingsPage'
import {StoragePage} from './Components/Pages/Storage/StoragePage'
import {ResourceBar} from './Components/ResourceBar/ResourceBar'


function App() {
    return (
        <>
            <BrowserRouter>
                <ResourceBar/>
                <Navigation/>
                <Routes>
                    <Route path="/"
                           element={<HomePage/>}/>
                    <Route path="/fortress"
                           element={<FortressPage/>}/>
                    <Route path="/surroundings"
                           element={<SurroundingsPage/>}/>
                    <Route path="/storage"
                           element={<StoragePage/>}/>
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App