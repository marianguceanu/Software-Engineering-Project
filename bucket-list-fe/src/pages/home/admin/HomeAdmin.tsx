import React from "react";
import {
  adminRemove,
  getPublicDestinations,
  headers,
} from "../../../util/urls";
import axios from "axios";
import style from "./HomeAdmin.module.scss";
import { Button, TextField } from "@mui/material";

interface Destination {
  id: number;
  geolocation: string;
  title: string;
  description: string;
  image: string;
  startDate: Date;
  endDate: Date;
  isPrivate: boolean;
}

export default function HomeAdmin(): JSX.Element {
  const username = window.localStorage.getItem("username");
  const url = `${getPublicDestinations}`;
  const [destinations, setDestinations] = React.useState<Destination[]>([]);

  React.useEffect(() => {
    axios
      .get(url, { headers })
      .then((res) => {
        setDestinations(res.data);
      })
      .catch((Error) => {});
  }, []);
  console.log(destinations);

  const handleDelete = (id: number) => {};

  const destinationComponents = destinations.map((dest) => {
    return (
      <div className={style.destinationWrapper}>
        <div className={style.details}>
          <h1>Destination {dest.id}</h1>
          <p>Geolocation: {dest.geolocation}</p>
          <p>Title: {dest.title}</p>
          <p>Description: {dest.description}</p>
          <p>Start date: {dest.startDate.toString()}</p>
          <p>End date: {dest.endDate.toString()}</p>
          <Button
            className={style.deleteButton}
            onClick={() => {
              handleDelete(dest.id);
            }}
          >
            Delete
          </Button>
          <Button className={style.updateButton}>Update</Button>
        </div>
        <img
          src={dest.image}
          alt="yey this not working"
          className={style.images}
        />
      </div>
    );
  });
  return (
    <div className={style.homeAdminContainer}>
      <div className={style.addDestinationForm}>
        <TextField />
      </div>
      {destinationComponents}
    </div>
  );
}
