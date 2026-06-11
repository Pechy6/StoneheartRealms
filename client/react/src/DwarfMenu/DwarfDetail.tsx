import {useState, useEffect} from 'react';

type Dwarf = {
    id: number,
    name: string,
    age: number,
    description: string,
    gender: string,
    energy: number,
    hunger: number,
    thirst: number
}

export const DwarfDetail = () => {
    const [dwarf, setDwarf] = useState<Dwarf | null>(null);

    const fetchDwarf = async (id: number) => {
        const response = await fetch(`/api/dwarves/${id}`);
        const data = await response.json();
        setDwarf(data);
    }

    useEffect(() => {
        fetchDwarf(1);
    }, []);

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