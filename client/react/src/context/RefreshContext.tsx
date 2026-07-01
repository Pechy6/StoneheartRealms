import { createContext, ReactNode, useContext, useState } from "react";

type RefreshContextType = {
    refreshVersion: number,
    triggerRefresh: () => void;
};

type RefreshProviderProps = {
    children: ReactNode;
}

const RefreshContext = createContext<RefreshContextType | undefined>(undefined);

export const RefreshProvider = ({children}: RefreshProviderProps) => {
    const [refreshVersion, setRefreshVersion] = useState(0);
    
    const triggerRefresh = () => {
        setRefreshVersion(currentVersion => currentVersion + 1);
    };
    
    return (
        <RefreshContext.Provider value={{refreshVersion, triggerRefresh}}>
            {children}
        </RefreshContext.Provider>
    );
};

export const useRefresh = () => {
    const context = useContext(RefreshContext);
    
    if (context === undefined){
        throw new Error('useRefresh must be used within a RefreshProvider');
    }
    
    return context;
}