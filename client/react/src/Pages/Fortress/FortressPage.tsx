import {DwarfTable} from '../../Components/Dwarf/DwarfTable.tsx'

//css 
import '../../styles/globals.css'

export const FortressPage = () => {
    return (
        <div>
            <h1>Fortress</h1>
            <div className="line"></div>
            <DwarfTable/>
        </div>
    )
}