import {useState, useEffect} from 'react';
import {useRefresh} from '../../context/RefreshContext.tsx'

type GameTime = {
    year: number,
    day: number,
    hour: number,
    currentTimeOfDay: number
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
    
    const getTImeOfDayText = (currentTimeOfDay?: number) => {
        if (currentTimeOfDay === 0)
            return 'IsDay';
        
        if (currentTimeOfDay === 1)
            return 'IsNight';
        
        return '';
    }
    
    useEffect(() => {
        fetchTime();
    }, [refreshVersion]);
    
    return(
        <>
            <p style={{color: 'black'}}>Day:{time?.day} Time: {time?.hour}:00 {getTImeOfDayText(time?.currentTimeOfDay)}</p>
        </>
    );
}