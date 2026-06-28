import {useState, useEffect} from 'react';

type ResourceBar = {
    amount: number,
    name: string
}

export const ResourceBar = () => {
    const [resources, setResources] = useState<ResourceBar[]>([]);
    
    const fetchResources = async () => {
        const response = await fetch('/api/storage');
        const data = await response.json();
        console.log(data);
        setResources(data);
    }

    useEffect(() => {
        fetchResources();
    }, []);
    
    return (
        <div>
            {resources.map((resource) => (
                <ul key={resource.resourceId}>
                    <li>{resource.resourceName} {resource.amount}</li>
                </ul>
            ))}
        </div>
    )
}