import {useState, useEffect} from 'react';
import {DwarfCard} from '../Dwarf/DwarfCard.tsx'
import '../../styles/DwarfTable.css'
import '../../styles/globals.css'
import {useRefresh} from '../../context/RefreshContext.tsx';
import {ProgressBar} from '../ProgressBar/ProgressBar.tsx'

enum DwarfState {
    Idle = 0,
    Working = 1,
    Sleeping = 2,
    Traveling = 3,
    Fighting = 4,
    Dead = 5,
}

type Dwarf = {
    id: number,
    name: string,
    energy: number,
    hunger: number,
    thirst: number,
    dwarfState: number,
    job: string
}

export const DwarfTable = () => {
    const [dwarves, setDwarves] = useState<Dwarf[]>([]);
    const [selectedDwarfId, setSelectedDwarfId] = useState<number | null>(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    
    const {refreshVersion} = useRefresh();

    //Mouse 
    const [canClose, setCanClose] = useState(false);

    const fetchDwarves = async () => {
        const response = await fetch('/api/dwarves');
        const data = await response.json();
        console.log(data);
        setDwarves(data);
    }
    
    const handleDelete = () => {
        fetchDwarves();
    }

    useEffect(() => {
        fetchDwarves();
    }, [refreshVersion]);

    return (
        <div>
            {isModalOpen && selectedDwarfId !== null &&
                <div className="modal-overlay"
                     onMouseDown={(e) => {
                         setCanClose(e.target === e.currentTarget);
                     }}
                     onMouseUp={() => {
                         if (canClose) {
                             setIsModalOpen(false);
                         }
                     }
                     }>
                    <div onClick={(e) =>
                        e.stopPropagation()
                    }>
                        <DwarfCard
                            id={selectedDwarfId}
                            isModalOpen={true}
                            setIsModalOpen={setIsModalOpen}
                            onAction={handleDelete}/>
                    </div>
                </div>}

            <h1>Dwarves</h1>
            <table>
                <thead>
                <tr className={'head-row'}>
                    <th>Name</th>
                    <th>Energy</th>
                    <th>Hunger</th>
                    <th>Thirst</th>
                    <th>State</th>
                    <th>Job</th>
                </tr>
                </thead>
                <tbody>
                {dwarves.map((dwarf) => (
                    <tr key={dwarf.id}
                        onClick={() => {
                            setSelectedDwarfId(dwarf.id);
                            setIsModalOpen(true);
                        }}>
                        <td className="name">{dwarf.name}</td>
                        <td><ProgressBar value={dwarf.energy} maxValue={100}/></td>
                        <td><ProgressBar value={dwarf.hunger} maxValue={100}/></td>
                        <td><ProgressBar value={dwarf.thirst} maxValue={100}/></td>
                        <td>{DwarfState[dwarf.dwarfState]}</td>
                        <td>{dwarf.job}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    )
}