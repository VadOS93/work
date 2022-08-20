import { useContext, useEffect } from 'react';
import { ValueContext } from '../App';
import { User } from '../models/User.model'

type UserProps = { user: User| null};

const UserComponent: React.FC<UserProps> = (props: UserProps) => {
const valuedata = useContext(ValueContext);
console.log(valuedata);

    useEffect(() => {
console.log("User component is ready");
        return () =>{
            console.log("User component is destroyed");
        }
      }, [])

    const result : JSX.Element = props.user !== null
     ? (<div>User: {props.user.data.first_name}</div>)
     : (<div>No Content</div>)
    
    return (
        <div className="user-info">
{result}
        </div>
    );
  }

export default UserComponent