import React from "react";
import { redirect } from "react-router-dom";
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
import { login } from "../../util/urls";
import axios from "axios";
import { type } from "os";

export interface User {
  username: string;
  password: string;
  type: string;
}

export default function Login({
  setUser,
}: React.SetStateAction<User | null>): JSX.Element {
  const [showPassword, setShowPassword] = React.useState(false);
  const handleClickShowPassword = () => setShowPassword(!showPassword);
  const handleMouseDownPassword = () => setShowPassword(!showPassword);
  const user: User = {
    username: "",
    password: "",
    type: "",
  };
  const handleButtonClick = () => {
    const email = (document.getElementById("email") as HTMLInputElement).value;
    const password = (document.getElementById("password") as HTMLInputElement)
      .value;
    const headers = {
      "Content-Type": "application/json",
      Accept: "text/plain",
    };
    setUser(user);
    console.log(JSON.stringify(user));
    axios.post(login, JSON.stringify(user), { headers }).then((res) => {
      console.log(res);
      if (res.data.status === "success") {
        redirect("/home");
      } else {
        alert("Login failed");
      }
    });
  };

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
          <TextField id="email" label="Email" className={style.email} />

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
