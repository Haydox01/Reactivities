import React from 'react'
import { Button, Item, Label, List, Segment } from 'semantic-ui-react'
import { Activity } from '../../../app/models/activity'

interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
    deleteActivity: (id: string) => void;
    submitting: boolean;
}

export default function ActivityList({activities, selectActivity, submitting, deleteActivity}: Props) {
    const [target, setTarget]= React.useState('' as string | undefined);
    function handleActivityDelete(e: React.MouseEvent<HTMLButtonElement>, id: string){
        setTarget(e.currentTarget.name);
        deleteActivity(id);
    }
  return (
    <Segment>
        <Item.Group divided>
            {activities.map(activity => (
                <Item key={activity.id}>
                    <Item.Content>
                        <Item.Header as='a'>
                            {activity.title}
                        </Item.Header>
                        <Item.Meta>{activity.date}</Item.Meta>
                        <Item.Description>
                            <div>{activity.description}</div>
                            <div>{activity.city}, {activity.venue}</div>
                        </Item.Description>
                        <Item.Extra>
                            <Button onClick={()=> selectActivity(activity.id)} floated='right' content='view' color='blue' />
                            <Button 
                            name={activity.id}
                            loading={submitting && target=== activity.id} 
                            onClick={(e)=> handleActivityDelete(e, activity.id)}
                             floated='right' 
                             content='delete' 
                             color='red' />
                            <Label basic content={activity.category} />
                        </Item.Extra>
                    </Item.Content>
                </Item>
            )) }

        </Item.Group>
    </Segment>
  )
}
