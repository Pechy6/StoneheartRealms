import {useState, useEffect} from 'react';

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

export const DwarfDetail = ({id, isModalOpen, setIsModalOpen}: DwarfDetailProps) => {
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
    <div>
        <h1>Detail</h1>
        <ul>
            <li>Name: {dwarf.name}</li>
            <li>Age: {dwarf.age}</li>
            <li>Gender: {dwarf.gender}</li>
            <li>Description: {dwarf.description}</li>
            <li>Energy: {dwarf.energy}</li>
            <li>Hunger: {dwarf.hunger}</li>
            <li>Thirst: {dwarf.thirst}</li>
        </ul>
        <button onClick={() => setIsModalOpen(false)}>X</button>
    </div>
)
}