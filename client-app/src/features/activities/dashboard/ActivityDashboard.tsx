import { useEffect } from 'react'
import { Grid, GridColumn, } from 'semantic-ui-react'
import ActivityList from './ActivityList';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponents from '../../../app/layout/LoadingComponents';
import ActivityFilters from './ActivityFilters';


export default observer(function ActivityDashboard() {

  const { activityStore } = useStore();
  const { loadActivities, activityRegistry } = activityStore;

  useEffect(() => {
    if (activityRegistry.size <= 1) loadActivities();
  }, [loadActivities, activityRegistry.size]);


  if (activityStore.loadingInitial) return <LoadingComponents content="Loading activities..." />

  return (
    <Grid>
      <Grid.Column width='10'>
        <ActivityList />
      </Grid.Column>
      <GridColumn width='6'>
        <ActivityFilters />
      </GridColumn>
    </Grid>
  )
});
