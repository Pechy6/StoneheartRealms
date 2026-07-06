import {useEffect} from "react";
import {useRefresh} from "../../context/RefreshContext";
import "../../styles/TickBtn.css"

export const TickButton = () => {
    
    const {triggerRefresh} = useRefresh();

    const fetchTick = async () => {
        const response = await fetch('/api/tick', {
            method: 'POST'
        });
        
        if (!response.ok){
            console.error('Failed to tick');
            return;
        }
        
        triggerRefresh();
    }
    
    return (
        <button className="btn" onClick={fetchTick}>Tick</button>
    )
}