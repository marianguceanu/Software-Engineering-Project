import React from "react";
import { redirect, useNavigate } from "react-router-dom";
import style from "./Login.module.scss";
import {
  TextField,
  InputAdornment,
  InputLabel,
  FormControl,
  OutlinedInput,
  IconButton,
  Button,
} from "@mui/material";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { headers, login } from "../../util/urls";
import axios from "axios";

export interface User {
  username: string;
  password: string;
  type: string;
}

export default function Login(props: any): React.JSX.Element {
  // States
  const navigate = useNavigate();
  const [showPassword, setShowPassword] = React.useState<boolean>(false);
  const handleClickShowPassword = () => setShowPassword(!showPassword);
  const handleMouseDownPassword = () => setShowPassword(!showPassword);
  const [sentUser, setSentUser] = React.useState<User>({
    username: "",
    password: "",
    type: "",
  });
  const [receivedUser, setReceivedUser] = React.useState<User>({
    username: "",
    password: "",
    type: "",
  });
  var [email, setEmail] = React.useState<string>("");
  var [password, setPassword] = React.useState<string>("");

  // Should change the sent user until the received user is changed
  React.useEffect(() => {
    setSentUser({
      username: email,
      password: password,
      type: "",
    });
    console.log(sentUser);
  }, [receivedUser]);

  // Button go brr
  function handleButtonClick() {
    setSentUser({
      username: email,
      password: password,
      type: "",
    });
    console.log(sentUser);

    axios
      .post(login, JSON.stringify(sentUser), { headers })
      .then((res) => {
        if (res.status === 200) {
          console.log("Received" + JSON.stringify(res.data));
          setReceivedUser(res.data);
          console.log(receivedUser);
          window.localStorage.setItem("username", res.data.username);
          window.localStorage.setItem("password", res.data.password);
          window.localStorage.setItem("type", res.data.type);
          if (res.data.type == "admin") {
            navigate("/home/admin");
          } else {
            navigate("/home/user");
          }
        } else {
          alert("Login failed");
        }
      })
      .catch((Error) => {});
  }

  return (
    <div className={style.container}>
      {/* Image */}
      <div className={style.loginImageDiv}>
        <img
          src="https://digitalnomads.world/wp-content/uploads/2021/01/bali-for-digital-nomads.jpg"
          alt="login image"
          className={style.loginImage}
        />
      </div>

      {/* Form */}
      <div className={style.loginFormContainer}>
        <h2 className={style.prompt}>Login to</h2>
        <h1 className={style.prompt}>BucketListManager</h1>

        {/* Inputs */}
        <div className={style.inputs}>
          {/* Email */}
          <TextField
            id="email"
            label="Email"
            className={style.email}
            onChange={() => {
              setEmail(
                (document.getElementById("email") as HTMLInputElement).value
              );
            }}
          />

          {/* Password */}
          <FormControl variant="outlined">
            <InputLabel htmlFor="password">Password</InputLabel>
            <OutlinedInput
              id="password"
              type={showPassword ? "text" : "password"}
              endAdornment={
                <InputAdornment position="end">
                  <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleClickShowPassword}
                    onMouseDown={handleMouseDownPassword}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
              label="Password"
              className={style.password}
              onChange={() => {
                setPassword(
                  (document.getElementById("password") as HTMLInputElement)
                    .value
                );
              }}
            />
          </FormControl>
        </div>
        <Button
          variant="outlined"
          className={style.logInButton}
          onClick={handleButtonClick}
        >
          Log in
        </Button>
      </div>
    </div>
  );
}
