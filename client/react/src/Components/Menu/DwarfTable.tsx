import {useState, useEffect} from 'react';
import {DwarfCard} from '../DwarfCard/DwarfCard.tsx'

type Dwarf = {
    id: number,
    name: string,
    age: number,
    gender: string,
    energy: number,
    hunger: number,
    thirst: number
}

export const DwarfTable = () => {
    const [dwarves, setDwarves] = useState<Dwarf[]>([]);
    const [selectedDwarfId, setSelectedDwarfId] = useState<number | null>(null);
    const [isModalOpen, setIsModalOpen] = useState(false);

    const fetchDwarves = async () => {
        const response = await fetch('/api/dwarves');
        const data = await response.json();
        setDwarves(data);
    }

    useEffect(() => {
        fetchDwarves();
    }, []);

    return (
        <div>
            {isModalOpen && selectedDwarfId !== null &&
                (<DwarfCard 
                        id={selectedDwarfId}
                        isModalOpen={true}
                        setIsModalOpen={setIsModalOpen}/>
                )}
            
            <h1>Dwarves</h1>
            <table>
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th>Gender</th>
                    <th>Energy</th>
                    <th>Hunger</th>
                    <th>Thirst</th>
                </tr>
                </thead>
                <tbody>
                {dwarves.map((dwarf) => (
                    <tr key={dwarf.id}
                        onClick={() => {
                            setSelectedDwarfId(dwarf.id);
                            setIsModalOpen(true);
                        }}>
                        <td>{dwarf.name}</td>
                        <td>{dwarf.age}</td>
                        <td>{dwarf.gender}</td>
                        <td>{dwarf.energy}</td>
                        <td>{dwarf.hunger}</td>
                        <td>{dwarf.thirst}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    )
}