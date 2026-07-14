import "../../styles/ProgressBar.css"

type ProgressProps = {
    value: number;
    maxValue: number;
}

export const ProgressBar = (props: ProgressProps) => {
    let width = (props.value / props.maxValue) * 100;
    
    let color;
    if (width >= 75)
        color = "green";
    else if (width < 75 && width > 25)
        color = "yellow";
    else
        color = "red";
    
    return (
        <div className="progress-bar">
            <div className="progress-bar-fill"
                 style={{width: width + "%", backgroundColor: color}}></div>
        </div>
    )
}