import {Link} from 'react-router-dom'

// css
import '../../styles/globals.css'


export const Navigation = () => {
    return (
        <nav>
            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/fortress">Fortress</Link></li>
                <li><Link to="/surroundings">Surroundings</Link></li>
                <li><Link to="/storage">Storage</Link></li>
            </ul>
        </nav>
    )
}