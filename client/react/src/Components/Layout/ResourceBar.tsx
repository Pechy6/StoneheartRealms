import {useState, useEffect} from 'react';
import {useRefresh} from '../../context/RefreshContext.tsx';
import "../../styles/ResourceBar.css"

type ResourceBar = {
    amount: number,
    name: string
}

export const ResourceBar = () => {
    const [resources, setResources] = useState<ResourceBar[]>([]);
    const {refreshVersion} = useRefresh();
    
    const fetchResources = async () => {
        const response = await fetch('/api/storage');
        const data = await response.json();
        console.log(data);
        setResources(data);
    }

    useEffect(() => {
        fetchResources();
    }, [refreshVersion]);
    
    return (
        <div className="resource-bar">
            {resources.map((resource) => (
                <ul key={resource.resourceId}>
                    <li className="resource-bar-li"><b>{resource.resourceName}:</b> {resource.amount}</li>
                </ul>
            ))}
        </div>
    )
}