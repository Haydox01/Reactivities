import { useEffect, useState } from 'react'
import { Button, Grid, GridColumn, } from 'semantic-ui-react'
import ActivityList from './ActivityList';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponents from '../../../app/layout/LoadingComponents';
import ActivityFilters from './ActivityFilters';
import { PagingParams } from '../../../app/layout/models/pagination';


export default observer(function ActivityDashboard() {

  const { activityStore } = useStore();
  const { loadActivities, activityRegistry, setPagingParams, pagination } = activityStore;
  const[loadingNext, setLoadingNext] = useState(false);

  function handleGetNext(){
    setLoadingNext(true);
    setPagingParams(new PagingParams(pagination!.currentPage + 1))
    loadActivities().then(() => setLoadingNext(false));
  }

  useEffect(() => {
    if (activityRegistry.size <= 1) loadActivities();
  }, [loadActivities, activityRegistry.size]);


  if (activityStore.loadingInitial) return <LoadingComponents content="Loading activities..." />

  return (
    <Grid>
      <Grid.Column width='10'>
        <ActivityList />
        <Button
        floated='right'
        content='More...'
        positive
        onClick={handleGetNext}
        loading={loadingNext}
        disabled={pagination?.totalPages === pagination?.currentPage} 
        />
      </Grid.Column>
      <GridColumn width='6'>
        <ActivityFilters />
      </GridColumn>
    </Grid>
  )
});
