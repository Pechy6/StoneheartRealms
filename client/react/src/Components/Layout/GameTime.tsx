import {useState, useEffect} from 'react';
import {useRefresh} from '../../context/RefreshContext.tsx'

type GameTime = {
    year: number,
    day: number,
    hour: number
}

export const GameTime = () => {
    const [time, setTime] = useState<GameTime>();
    const {refreshVersion} = useRefresh();
    
    const fetchTime = async () => {
        const response = await fetch('/api/GameTime');
        const data = await response.json();
        console.log(data);
        setTime(data);
    }
    
    useEffect(() => {
        fetchTime();
    }, [refreshVersion]);
    
}