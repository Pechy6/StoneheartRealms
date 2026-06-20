import {useState, useEffect} from 'react';
import './DwarfCard.css'

enum Gender {
    Male = 0,
    Female = 1,
}

type Dwarf = {
    name: string,
    age: number,
    description: string,
    gender: string,
    energy: number,
    hunger: number,
    thirst: number,
    job: string,
    jobId: number
}
type DwarfDetailProps = {
    id: number
    isModalOpen: boolean
    setIsModalOpen: (isModalOpen: boolean) => void
    onAction: () => void
}

type Jobs ={
    id: number,
    name: string
}

export const DwarfCard = ({id, isModalOpen, setIsModalOpen, onAction}: DwarfDetailProps) => {
    // Dwarf 
    const [dwarf, setDwarf] = useState<Dwarf | null>(null);

    // Delete
    const [showDeleteConfirmation, setShowDeleteConfirmation] = useState(false);

    // Update
    const [isUpdating, setIsUpdating] = useState(false);
    const [editName, setEditName] = useState('');
    const [editDescription, setEditDescription] = useState('');
    
    //Jobs
    const [jobs, setJobs] = useState<Jobs[]>([]);
    const [selectedJobId, setSelectedJobId] = useState<number | null>(null);
    
    // Fetch data
    const fetchDwarf = async (id: number) => {
        const response = await fetch(`/api/dwarves/${id}`);
        const data = await response.json();
        setDwarf(data);
    }

    const fetchDelete = async (id: number) => {
        const response = await fetch(`/api/dwarves/${id}`, {
            method: 'DELETE'
        });
        if (response.ok) {
            onAction();
            setIsModalOpen(false);
        }
    }
    
    //Jobs
    const fetchJobs = async () => {
        const response = await fetch('/api/jobs');
        const data = await response.json();
        setJobs(data);
    }
    
        
    const handleSaveUpdate = async (e: React.FormEvent) => {
        e.preventDefault();
        
        const response = await fetch(`/api/dwarves/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: editName,
                description: editDescription,
            })
        });
        
        if (!response.ok){
            return;
        }
        
        if (selectedJobId !== null) {
            debugger;
            const jobResponse = await fetch(`/api/dwarves/${id}/job/${selectedJobId}`, {
                method: 'PUT'
            });
            
            if (!jobResponse.ok){
                return;
            }
            
            await fetchDwarf(id);
            onAction();
            setIsUpdating(false);
            debugger;
        }
    }

    useEffect(() => {
        fetchDwarf(id);
    }, [id]);

    useEffect(() => {
        fetchJobs();
    }, []);

    // delete
    const handleDelete = () => {
        setShowDeleteConfirmation(true);
    }
    
    const handleUpdate = () => {
        setIsUpdating(true);
        setEditName(dwarf?.name || '');
        setEditDescription(dwarf?.description || '');
        setSelectedJobId(dwarf?.jobId ?? null);
    }
    

    if (!isModalOpen)
        return null;

    if (!dwarf) {
        return <div>Loading...</div>;
    }

    return (
        <div className="DwarfCard">
            <button className="close-button"
                    onClick={() => setIsModalOpen(false)}>X
            </button>
            <h1>Detail</h1>
            <ul>
                <li><span>Name:</span> {dwarf.name}</li>
                <li><span>Age:</span> {dwarf.age}</li>
                <li><span>Gender:</span> {Gender[dwarf.gender]}</li>
                <li><span>Description:</span> {dwarf.description}</li>
                <li><span>Job:</span> {dwarf.job}</li>
                <li><span>Energy:</span> {dwarf.energy}</li>
                <li><span>Hunger:</span> {dwarf.hunger}</li>
                <li><span>Thirst:</span> {dwarf.thirst}</li>
                <button onClick={handleDelete}>Delete</button>
                <button onClick={handleUpdate}>Update</button>
            </ul>

            {showDeleteConfirmation && (
                <div className="delete-confirmation">
                    <p>Are you sure you want to delete:<span className="delete-name">{dwarf.name}</span></p>
                    <button onClick={() => fetchDelete(id)}>Yes</button>

                    <button onClick={() => setShowDeleteConfirmation(false)}>No</button>
                </div>
            )}

            {isUpdating && (
                <div className="update-confirmation">
                    <form onSubmit={handleSaveUpdate}>
                        <p>Name:</p>
                        <input type="text"
                               value={editName}
                               onChange={(e) => setEditName(e.target.value)}/>
                        <p>Description</p>
                        <textarea className="description" type="text"
                               value={editDescription}
                               onChange={(e) => setEditDescription(e.target.value)}/>
                        <select value={selectedJobId ?? ''} onChange={(e) => setSelectedJobId(Number(e.target.value))}>
                            {jobs.map((job) => (
                                <option key={job.id} value={job.id}>
                                    {job.name}
                                </option>
                            ))}
                        </select>
                        <br/>
                        <button type="submit" className="submit-btn">Save</button>
                    </form>
                </div>
            )}
        </div>
    )
}