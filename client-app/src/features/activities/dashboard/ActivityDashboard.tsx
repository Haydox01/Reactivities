import React from 'react'
import { Activity } from '../../../app/models/activity'
import { Grid, GridColumn, List } from 'semantic-ui-react'
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';

interface Props {
    activities: Activity[];
}

export default function ActivityDashboard({activities}: Props) {
  return (
    <Grid>
        <Grid.Column width='10'>
            <ActivityList activities={activities}/>
        </Grid.Column>
        <GridColumn width='6'>
            {activities[0] &&
            <ActivityDetails activity={activities[0]}/>}
            <ActivityForm />
        </GridColumn>
    </Grid>
  )
}