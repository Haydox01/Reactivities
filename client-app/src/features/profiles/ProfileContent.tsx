import { Tab, TabPane } from "semantic-ui-react";
import ProfilePhotos from "./ProfilePhotos";
import { observer } from "mobx-react-lite";
import { Profile } from "../../app/layout/models/profile";
import ProfileAbout from "./ProfileAbout";
import ProfileFollowings from "./ProfileFollowings";
import { useStore } from "../../app/stores/store";

interface Props {
    profile: Profile;   
}

export default observer(function ProfileContent({ profile }: Props) {
  const {profileStore} = useStore();
  const panes = [
    { menuItem: "About", render: () => <ProfileAbout /> },
    { menuItem: "Photos", render: () => <ProfilePhotos profile={profile} /> },
    { menuItem: "Events", render: () => <TabPane>About Content</TabPane> },
    { menuItem: "Followers", render: () => <ProfileFollowings /> },
    { menuItem: "Following", render: () => <ProfileFollowings /> },
  ];
  return (
    <Tab
      panes={panes}
      menu={{ fluid: true, vertical: true }}
      menuPosition="right"
      onTabChange={(_, data) => profileStore.setActiveTab(data.activeIndex as number)}
    />
  );
})

