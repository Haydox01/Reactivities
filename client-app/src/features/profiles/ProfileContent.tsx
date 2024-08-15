import { Tab, TabPane } from "semantic-ui-react";
import ProfilePhotos from "./ProfilePhotos";
import { observer } from "mobx-react-lite";
import { Profile } from "../../app/layout/models/profile";

interface Props {
    profile: Profile;   
}

export default observer(function ProfileContent({ profile }: Props) {
  const panes = [
    { menuItem: "About", render: () => <TabPane>About Content</TabPane> },
    { menuItem: "Photos", render: () => <ProfilePhotos profile={profile} /> },
    { menuItem: "Events", render: () => <TabPane>About Content</TabPane> },
    { menuItem: "Followers", render: () => <TabPane>About Content</TabPane> },
    { menuItem: "Following", render: () => <TabPane>About Content</TabPane> },
  ];
  return (
    <Tab
      panes={panes}
      menu={{ fluid: true, vertical: true }}
      menuPosition="right"
    />
  );
})
