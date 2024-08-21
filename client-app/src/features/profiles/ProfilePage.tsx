import { useEffect } from 'react'
import { Grid } from 'semantic-ui-react';
import ProfileHeader from './ProfileHeader';
import ProfileContent from './ProfileContent';
import { observer } from 'mobx-react-lite';
import { useParams } from 'react-router-dom';
import { useStore } from '../../app/stores/store';
import LoadingComponents from '../../app/layout/LoadingComponents';

export default observer(function ProfilePage() {
    const {username} = useParams<{username: string}>();
    const {profileStore} = useStore();
    const {loadingProfile, profile, loadProfile, setActiveTab} = profileStore;

    useEffect(() => {
        if(username) loadProfile(username);
        return () => {
          setActiveTab(0);
        }
    }, [username, loadProfile]);

    if(loadingProfile) return <LoadingComponents content='Loading profile...'/>
  return (
    <Grid>
      <Grid.Column width="16">
        {profile &&
        <>
        <ProfileHeader profile={profile} />
        <ProfileContent profile={profile}  />
        </>}
        
      </Grid.Column>
    </Grid>
  );
})
