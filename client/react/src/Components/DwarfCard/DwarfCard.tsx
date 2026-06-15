import {useState, useEffect} from 'react';
import './DwarfCard.css'

type Dwarf = {
    name: string,
    age: number,
    description: string,
    gender: string,
    energy: number,
    hunger: number,
    thirst: number
}
type DwarfDetailProps = {
    id: number
    isModalOpen: boolean
    setIsModalOpen: (isModalOpen: boolean) => void
}

export const DwarfCard = ({id, isModalOpen, setIsModalOpen}: DwarfDetailProps) => {
    const [dwarf, setDwarf] = useState<Dwarf | null>(null);

    const fetchDwarf = async (id: number) => {
        const response = await fetch(`/api/dwarves/${id}`);
        const data = await response.json();
        setDwarf(data);
    }
    
    const ender = () => {
        console.log("ender")
    }

    useEffect(() => {
        fetchDwarf(id);
    }, [id]);

    if (!isModalOpen)
        return null;
    
    if (!dwarf) {
        return <div>Loading...</div>;
    }
    
    return (
    <div className="DwarfCard">
        <button onClick={() => setIsModalOpen(false)}>X</button>
        <h1>Detail</h1>
        <ul>
            <li><span>Name:</span> {dwarf.name}</li>
            <li><span>Age:</span> {dwarf.age}</li>
            <li><span>Gender:</span> {dwarf.gender}</li>
            <li><span>Description:</span> {dwarf.description}</li>
            <li><span>Energy:</span> {dwarf.energy}</li>
            <li><span>Hunger:</span> {dwarf.hunger}</li>
            <li><span>Thirst:</span> {dwarf.thirst}</li>
        </ul>
        
    </div>
)
}