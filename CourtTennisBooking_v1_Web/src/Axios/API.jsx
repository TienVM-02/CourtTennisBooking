import axios from "axios";
// import * as URL from "./URL";

export default function API(method, url, body, token) {
  return axios({
    method: method,
    url: url,
    data: body,
    headers: { Authorization: `Bearer ${token}` },
  });
}
