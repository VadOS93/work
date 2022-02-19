import React, { useState, useEffect } from 'react';

import Container from 'react-bootstrap/Container';
import ListGroup from 'react-bootstrap/ListGroup';
import Badge from 'react-bootstrap/Badge';
import Spinner from 'react-bootstrap/Spinner';
import { Card } from 'react-bootstrap';

export const ValueContext = React.createContext("value context");

interface IListItemProps {
  title: string;
  description: string;
  count: number;
}

const ListItem = (props: IListItemProps) => (
          <ListGroup.Item as="li"
                          className="d-flex justify-content-between align-items-start">
                            <div className="ms-2 me-auto">
                              <div className="fw-bold">{props.title}</div>
                              {props.description}
                            </div>
                          <Badge bg="primary" pill>
                              {props.count}
                          </Badge>
          </ListGroup.Item>
  );

interface IListProps {
    children: React.ReactNode;
}

const List = (props: IListProps) => (
  <ListGroup as="ol" numbered>
    {props.children}
  </ListGroup>
)

function App() {
  const [loading, setLoading] = useState(true);
  const [header, setHeader] = useState('');

  function sleep(ms : number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  async function longOperation() : Promise<string> {
    const text = "Custom list";
    await sleep(2000);
    return text;
  }

  // Similar to componentDidMount and componentDidUpdate:
  useEffect(() => {

    async function init() {
      const result = await longOperation();
      setHeader(result);
      setLoading(false);
    }

    init();
  });

  return <>
  <UserComponent />
  <ListComponent />
</>;
}

interface IEmployee {
  name: string;
  job: string;
  id: number;
  createdAt: string;
  updatedAt: string;
}
interface IUserData {
  data: IUser;
}
interface IUser {
  email: string;
  first_name: string;
  id: number;
  last_name: string;
  url_avatar: string;
}

async function get() : Promise<IUserData> {
  const response = await fetch('https://reqres.in/api/users/2');
  return await response.json();
}

async function post() : Promise<IEmployee> {
  const requestOptions = {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ name: 'morpheus', job: 'leader' })
  };
  const response = await fetch('https://reqres.in/api/users', requestOptions);
  return await response.json();
}

async function put() : Promise<IEmployee> {
  const requestOptions = {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ name: 'morpheus', job: 'zion resident' })
  };
  const response = await fetch('https://reqres.in/api/users/2', requestOptions);
  return await response.json();
}

async function patch() : Promise<IEmployee> {
  const requestOptions = {
    method: 'PATCH',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ name: 'jack', job: 'zion resident' })
  };
  const response = await fetch('https://reqres.in/api/users/2', requestOptions);
  return await response.json();
}

async function deleteUser() : Promise<void> {
  const requestOptions = {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' }
  };
  await fetch('https://reqres.in/api/users/2', requestOptions);
}

export function UserComponent() {

  const [createdUser, setCreatedUser] = React.useState<IUser[]>([]);

  const [emploee, setEmploee] = React.useState<IEmployee[]>([]);

  const [updatedUserPut, setUpdatedUserPut] = React.useState<IEmployee[]>([]);

  const [updatedUserPatch, setUpdatedUserPatch] = React.useState<IEmployee[]>([]);
  
  useEffect(() => {

    async function init() {
        const resultGet = await get();
        setCreatedUser([resultGet.data]);
        const resultPost = await post();
        setEmploee([resultPost]);
        const resultPut = await put();
        setUpdatedUserPut([resultPut]);
        const resultPatch = await patch();
        setUpdatedUserPatch([resultPatch]);
        await deleteUser();
    }

     init();
  }, []);

  return(<>
            {createdUser.map(item => (
                    <ListItem key={item.id} title={item.email} description={item.first_name + ' ' + item.last_name} count={item.id}  />
                  ))}
            {emploee.map(item => (
                    <ListItem key={item.id} title={item.job} description={item.name} count={item.id}  />
                  ))}
            {updatedUserPut.map(item => (
                    <ListItem key={item.id} title={item.job} description={item.name} count={item.id}  />
                  ))}
            {updatedUserPatch.map(item => (
                    <ListItem key={item.id} title={item.job} description={item.name} count={item.id}  />
                  ))}
          </>);
}

interface IResourceData {
  data: IResource[];
}
interface ISingleResourceData {
  data: IResource;
}
interface IResource {
  id: number;
  name: string;
  year: number;
  color: string;
  pantone_value: string;
}

async function getSingleResource() : Promise<ISingleResourceData> {
  const response = await fetch('https://reqres.in/api/unknown/2');
  return await response.json();
}

async function getResources() : Promise<IResourceData> {
  const response = await fetch('https://reqres.in/api/unknown');
  return await response.json();
}

async function getNotFoundResource() : Promise<IResourceData> {
  const response = await fetch('https://reqres.in/api/unknown/23');
  return await response.json();
}

export function ListComponent() {

  const [singleResource, setSingleResource] = React.useState<IResource[]>([]);
  const [resources, setResources] = React.useState<IResource[]>([]);

  useEffect(() => {

    async function init() {
        const resultSingleResource = await getSingleResource();        
        setSingleResource([resultSingleResource.data]);
        const resultResources = await getResources();        
        setResources(resultResources.data);
        const resultNotFoundResource = await getNotFoundResource();
        console.log(resultNotFoundResource);
    }

     init();
  }, []);


  return(<>
    <div>List Component</div>
    {singleResource.map(item => (
      <Card key={item.id} style={{ background: item.color }}>
        <Card.Header>Single resource</Card.Header>
        <Card.Body>
          <Card.Title>Name: {item.name}</Card.Title>
          <Card.Text>
            year: {item.year}, pantone_value: {item.pantone_value}
          </Card.Text>
        </Card.Body>
      </Card>
    ))}

    <Card>
      <Card.Header>Resources</Card.Header>
    </Card>

    {resources.map(item => (
      <Card key={item.id} style={{ background: item.color }}>
        <Card.Body>
          <Card.Title>Name: {item.name}</Card.Title>
          <Card.Text>
            year: {item.year}, pantone_value: {item.pantone_value}
          </Card.Text>
        </Card.Body>
      </Card>
    ))}
  </>);
}

export default App;
