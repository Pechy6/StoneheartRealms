import {Navigation} from './Navigation.tsx';
import {ResourceBar} from './ResourceBar.tsx';
import {TickButton} from './TickButton.tsx';
import {GameTime} from './GameTime.tsx';

import {Outlet} from 'react-router-dom';

export const  GameLayout = () => {
    return (
        <div>
            <ResourceBar/>
            <Navigation/>
            <GameTime/>
            <TickButton/>
            <Outlet/>
        </div>
    )
}