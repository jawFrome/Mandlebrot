import { Counter } from "./components/Counter";
import { FetchNet6Data } from "./components/FetchNet6Data";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-net6-data',
    element: <FetchNet6Data />
  }
];

export default AppRoutes;
