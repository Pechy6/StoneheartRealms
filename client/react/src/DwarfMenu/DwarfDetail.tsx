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
}

export const DwarfDetail = ({id}: DwarfDetailProps) => {
    const [dwarf, setDwarf] = useState<Dwarf | null>(null);

    const fetchDwarf = async (id: number) => {
        const response = await fetch(`/api/dwarves/${id}`);
        const data = await response.json();
        setDwarf(data);
    }

    useEffect(() => {
        fetchDwarf(id);
    }, [id]);

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
    </div>
)
}