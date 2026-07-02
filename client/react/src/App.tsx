import {BrowserRouter, Routes, Route} from 'react-router-dom'
// Nav
import {HomePage} from './Pages/Home/HomePage.tsx'
import {FortressPage} from './Pages/Fortress/FortressPage.tsx'
import {SurroundingsPage} from './Pages/Surroundings/SurroundingsPage.tsx'
import {StoragePage} from './Pages/Storage/StoragePage.tsx'
import {RefreshProvider} from './context/RefreshContext'
import {GameLayout} from './Components/Layout/GameLayout.tsx'


function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/"
                           element={<HomePage/>}/>
                    
                        <Route element={
                            <RefreshProvider>
                                <GameLayout/>
                            </RefreshProvider>
                        }>
                            <Route path="/fortress"
                                   element={<FortressPage/>}/>
                            <Route path="/surroundings"
                                   element={<SurroundingsPage/>}/>
                            <Route path="/storage"
                                   element={<StoragePage/>}/>
                        </Route>
                </Routes>
            </BrowserRouter>
        </>
    )
}

export default App